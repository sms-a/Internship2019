package com.company.spellchecker.beans.interpreter;

import com.company.spellchecker.api.interpreter.SpellCheckInterpreter;
import com.company.spellchecker.api.metrics.MetricsService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.*;
import java.util.stream.Collectors;

@Component(SpellCheckInterpreter.NAME)
public class SpellCheckInterpreterBean implements SpellCheckInterpreter {

    private static final String TERMINAL_TOKEN = "===";

    @Autowired
    private InterpreterHelper helper;
    @Autowired
    private MetricsService metricsService;

    private Set<String> dictionary = new TreeSet<>();
    private String[] scanningWords;

    @Override
    public String interpretText(String[] args) {
        if(args == null){
            throw new IllegalArgumentException("Cannot interpret null strings");
        }

        dictionary = new TreeSet<>();
        scanningWords = null;

        scan(args);

        return buildResult();
    }

    private String buildResult() {
        StringBuilder builder = new StringBuilder();

        Arrays.stream(scanningWords)
                .map(this::getTranslatedView)
                .forEach(builder::append);

        return builder.toString().trim();
    }

    private String getTranslatedView(String input) {
        class StringIntPair {
            public final String string;
            public final int cost;

            public StringIntPair(String str, int cost) {
                this.string = str;
                this.cost = cost;
            }
        }

        StringBuilder builder = new StringBuilder();

        List<StringIntPair> nearestString = dictionary.stream()
                .map(x -> new StringIntPair(x, metricsService.getMetrics(x, input)))
                .filter(x -> x.cost <= metricsService.MAX_COST)
                .sorted(Comparator.comparingInt(x -> x.cost))
                .collect(Collectors.toList());

        if (nearestString.isEmpty()) {
            builder.append("{")
                    .append(input)
                    .append("?} ");
        } else {
            int minCost = nearestString.get(0).cost;
            nearestString = nearestString.stream()
                    .filter(x -> x.cost <= minCost)
                    .collect(Collectors.toList());

            if(nearestString.size() == 1) {
                builder.append(nearestString.get(0).string + " ");
            } else {
                builder.append("{");

                for (StringIntPair pair : nearestString) {
                    if(minCost > pair.cost) break;
                    builder.append(pair.string + " ");
                }

                builder.insert(builder.lastIndexOf(" "), "}");
            }
        }

        return builder.toString();
    }

    private void scan(String[] args) {
        InterpreterHelper.StringPair inputPair = helper.translateInputStrings(TERMINAL_TOKEN, args);
        buildScanning(inputPair.second);
        buildDictionary(inputPair.first);
    }

    private void buildDictionary(String input) {
        String[] words = input.trim().split(" ");

        dictionary.addAll(Arrays.asList(words));
    }

    private void buildScanning(String input) {
        scanningWords = input.trim().split(" ");
    }
}
