package com.company.spellchecker.beans.mertrics;

import com.company.spellchecker.ApplicationConfig;
import com.company.spellchecker.api.metrics.MetricsService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import static org.junit.Assert.*;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = {ApplicationConfig.class})
public class MetricsServiceBeanTest {

    @Autowired
    private MetricsService metricsService;

    @Test
    public void simplestEquals() {
        String first = "aaaa";
        String second = "aaaa";

        int result = metricsService.getMetrics(first, second);

        assertEquals(0, result);
    }

    @Test
    public void addOneLetter() {
        String first = "aaa";
        String second = "acaa";

        int result = metricsService.getMetrics(first, second);

        assertEquals(1, result);
    }

    @Test
    public void addTwoLetter() {
        String first = "a";
        String second = "bab";

        int result = metricsService.getMetrics(first, second);

        assertEquals(2, result);
    }

    @Test
    public void oneLetterDiff() {
        String first = "aaaaa";
        String second = "aabaa";

        int result = metricsService.getMetrics(first, second);

        assertEquals(2, result);
    }

    @Test
    public void twoLetterDiff() {
        String first = "aaaaa";
        String second = "ababa";

        int result = metricsService.getMetrics(first, second);

        assertEquals(4, result);
    }

    @Test
    public void adjacentChars() {
        String first = "acca";
        String second = "aa";

        int result = metricsService.getMetrics(first, second);

        assertTrue(result > metricsService.MAX_COST);
    }

    @Test
    public void emptyStrings() {
        String first = "";
        String second = "";

        int result = metricsService.getMetrics(first, second);

        assertEquals(0, result);
    }

    @Test(expected = IllegalArgumentException.class)
    public void nullabilityTest() {
        String first = null;
        String second = null;

        int result = metricsService.getMetrics(first, second);
    }

    @Test
    public void oneLetter() {
        String first = "first";
        String firs = "firs";

        int result = metricsService.getMetrics(first, firs);

        assertEquals(1, result);
    }

    @Test
    public void reverseLetters() {
        String first = "plaint";
        String second = "pliant";

        int result = metricsService.getMetrics(first, second);

        assertEquals(2, result);
    }
}