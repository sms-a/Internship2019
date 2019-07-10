package com.company.spellchecker.api.metrics;

public interface MetricsService {

    String NAME = "checker_MetricsService";
    int MAX_COST = 2;

    int getMetrics(String first, String second);
}
