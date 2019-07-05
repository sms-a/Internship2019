package com.company.spellchecker;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import static org.junit.Assert.*;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = {ApplicationConfig.class})
public class SimpleTests {

    @Autowired
    private SpellCheckInterpreter interpreter;

    @Test
    public void SameTextsTest() {
        String text = "first second third ===";
        String dictionary = "first second third ===";

        String result = interpreter.interpretText(dictionary, text);

        assertEquals("first second third", result);
    }
}