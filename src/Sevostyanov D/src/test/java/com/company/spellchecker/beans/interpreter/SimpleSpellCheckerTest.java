package com.company.spellchecker.beans.interpreter;

import com.company.spellchecker.ApplicationConfig;
import com.company.spellchecker.api.interpreter.SpellCheckInterpreter;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import static org.junit.Assert.assertEquals;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = {ApplicationConfig.class})
public class SimpleSpellCheckerTest {

    @Autowired
    private SpellCheckInterpreter interpreter;

    @Test
    public void sameTexts() {
        String[] args = new String[] { "first", "second", "third", "===", "first", "second", "third", "===" };

        String result = interpreter.interpretText(args);

        assertEquals("first second third", result);
    }

    @Test
    public void oneLetterDiffTexts() {
        String[] args = new String[] { "first", "second", "===", "firs", "second", "==="};

        String result = interpreter.interpretText(args);

        assertEquals("first second", result);
    }

    @Test
    public void fullyDifferent() {
        String[] args = new String[] { "abcd", "first", "===", "jgfrf", "second", "==="};

        String result = interpreter.interpretText(args);

        assertEquals("{jgfrf?} {second?}", result);
    }

    @Test
    public void taskSample() {
        String[] args = new String[]{
                "rain", "spain", "plain", "plaint", "pain", "main", "mainly", "the", "in", "on", "fall",
                "falls", "his", "was", "===",
                "hte", "rame", "in", "pain", "fells", "mainy", "oon", "teh", "lain", "was",
                "hints", "pliant", "==="
        };

        String result = interpreter.interpretText(args);

        String expected = "the {rame?} in pain falls {main mainly} on the plain was {hints?} plaint";
        assertEquals(expected, result);
    }
}