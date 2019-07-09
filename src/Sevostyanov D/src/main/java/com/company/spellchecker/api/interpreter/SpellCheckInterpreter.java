package com.company.spellchecker.api.interpreter;

public interface SpellCheckInterpreter {

    String NAME = "checker_SpellCheckInterpreter";

    String interpretText(String[] args);
}
