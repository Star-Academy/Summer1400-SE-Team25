package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class NOTOperator implements Operator {
    private String queryString;
    private InvertedIndex index;

    public NOTOperator(String queryString, InvertedIndex index) {
        this.queryString = queryString.substring(1);
        this.index = index;
    }

    @Override
    public Set<DocumentFile> operate(Set<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            prevSearchResult.removeAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
