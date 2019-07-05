package com.company.spellchecker;

import org.springframework.stereotype.Service;

@Service(SpellCheckInterpreter.NAME)
public class SpellCheckInterpreterBean implements SpellCheckInterpreter {

    @Override
    public String interpretText(String dictionary, String text) {
        return "===";
    }
}
