package com.company.spellchecker;

public interface SpellCheckInterpreter {

    String NAME = "checker_SpellCheckInterpreter";

    String interpretText(String dictionary, String text);
}
