package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class ANDOperator implements Operator {
    private String queryString;
    private InvertedIndex index;

    public ANDOperator(String queryString, InvertedIndex index) {
        this.queryString = queryString;
        this.index = index;
    }

    @Override
    public Set<DocumentFile> operate(Set<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            prevSearchResult.retainAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
