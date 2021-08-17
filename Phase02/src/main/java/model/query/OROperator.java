package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class OROperator implements Operator {
    private String queryString;
    private InvertedIndex index;

    public OROperator(String queryString, InvertedIndex index) {
        this.queryString = queryString.substring(1);
        this.index = index;
    }

    @Override
    public Set<DocumentFile> operate(Set<DocumentFile> prevSearchResult, WordUtil wordUtil) {
        String simpleWord = wordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            prevSearchResult.addAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
