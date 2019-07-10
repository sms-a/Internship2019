package com.company.spellchecker.beans.mertrics;

import com.company.spellchecker.api.metrics.MetricsService;
import org.springframework.stereotype.Component;

import static org.springframework.util.StringUtils.isEmpty;

@Component(MetricsService.NAME)
public class MetricsServiceBean implements MetricsService {

    private static final int RANDOM_SET_COST = 2;

    @Override
    public int getMetrics(String first, String second) {
        if(first == null || second == null) throw new IllegalArgumentException("Cannot calculate metrics for nulls");
        if(isEmpty(first) || isEmpty(second)) return Math.max(first.length(), second.length());

        if(first.length() > second.length()) {
            String tmp = second;
            second = first;
            first = tmp;
        }

        char[] firstArr = first.toCharArray();
        char[] secondArr = second.toCharArray();
        int[][] dynamic = new int[firstArr.length + 1][secondArr.length + 1];
        int[][] prevI = new int[firstArr.length+1][secondArr.length+1];
        int[][] prevJ = new int[firstArr.length+1][secondArr.length+1];
        int[][] prevOp = new int[firstArr.length+1][secondArr.length+1];

        for (int i = 0; i <= firstArr.length; ++i) {
            dynamic[i][0] = i;
        }
        for (int i = 0; i <= secondArr.length; ++i) {
            dynamic[0][i] = i;
        }

        for (int i = 1; i <= firstArr.length; ++i) {
            for (int j = 1; j <= secondArr.length; ++j) {
                int upperVariant = dynamic[i][j-1] + 1;
                int leftVariant = dynamic[i-1][j] + 1;
                int leftUpperVariant = dynamic[i-1][j-1];

                // skip equals
                if(firstArr[i-1] != secondArr[j-1]) {
                    leftUpperVariant += RANDOM_SET_COST;
                }

                if(leftUpperVariant <= Math.min(leftVariant, upperVariant)) {
                    dynamic[i][j] = leftUpperVariant;
                    prevI[i][j] = i-1;
                    prevJ[i][j] = j-1;
                    prevOp[i][j] = 0;
                } else if(leftVariant < upperVariant) {
                    dynamic[i][j] = leftVariant;
                    prevI[i][j] = i-1;
                    prevJ[i][j] = j;
                    if(i < j) prevOp[i][j] = -1;
                } else {
                    dynamic[i][j] = upperVariant;
                    prevI[i][j] = i;
                    prevJ[i][j] = j-1;
                    if(j > i) prevOp[i][j] = 1;
                }
            }
        }

        int i = firstArr.length;
        int j = secondArr.length;
        int ops = 0;
        while (i > 0 && j > 0) {
            ops += prevOp[i][j];
            if(prevOp[i][j] == 0) ops = 0;
            i = prevI[i][j];
            j = prevJ[i][j];
            if(Math.abs(ops) >= 2) return MAX_COST+1;
        }
        return dynamic[firstArr.length][secondArr.length];
    }
}
