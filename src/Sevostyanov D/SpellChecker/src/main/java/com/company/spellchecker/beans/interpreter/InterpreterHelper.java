package com.company.spellchecker.beans.interpreter;

import org.springframework.stereotype.Component;

import java.util.Arrays;
import java.util.stream.Collectors;

@Component(InterpreterHelper.NAME)
public class InterpreterHelper {

    public static final String NAME = "checker_InterpreterHelper";

    public static class StringPair {

        public final String first;
        public final String second;

        private StringPair(String first, String second) {
            this.first = first;
            this.second = second;
        }
    }

    public StringPair translateInputStrings(String token, String[] args) {
        if (token == null || args == null) {
            throw new IllegalArgumentException("Cannot translate nulls");
        }

        StringBuilder firstString = new StringBuilder();
        StringBuilder secondString = new StringBuilder();
        int index = 0;

        for (; index < args.length && !token.equals(args[index]); ++index) {
            firstString.append(args[index] + " ");
        }

        index++;

        for (; index < args.length && !token.equals(args[index]); ++index) {
            secondString.append(args[index] + " ");
        }

        if (index == args.length) {
            throw new IllegalArgumentException("Arguments did not ends by token");
        }

        return new StringPair(
                firstString.toString(),
                secondString.toString());
    }
}
