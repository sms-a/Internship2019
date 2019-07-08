package com.company.spellchecker.beans.controllers;

import com.company.spellchecker.ApplicationConfig;
import com.company.spellchecker.api.interpreter.SpellCheckInterpreter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

@Component
public class ConsoleController {

    public static final String NAME = "checker_ConsoleController";

    private static Scanner scanner = new Scanner(System.in);

    @Autowired
    private SpellCheckInterpreter interpreter;

    public static void main(String... args) {
        ApplicationContext context = new AnnotationConfigApplicationContext(ApplicationConfig.class);
    }

    @PostConstruct
    private void init() {
        System.out.println("Hello in SpellChecker application!\n" +
                "You should enter a dictionary and phrase after it\n" +
                "All texts (dictionary and phrase) must ends by ===\n\n" );

        String result = handleInput();

        System.out.println("Result: \n");
        System.out.println(result);
    }

    private String handleInput() {
        String data[] = this.readData();

        return interpreter.interpretText(data);
    }

    private String[] readData() {
        int countOfTerms = 0;
        List<String> inputStrings = new ArrayList<>();

        while(countOfTerms < 2) {
            String element = scanner.next();
            inputStrings.add(element);
            if("===".equals(element)) countOfTerms++;
        }

        return inputStrings.toArray(new String[0]);
    }
}
