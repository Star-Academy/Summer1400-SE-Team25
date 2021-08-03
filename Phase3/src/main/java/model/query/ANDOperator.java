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
    public Set<DocumentFile> operate(Set<DocumentFile> previewSearchResult, WordUtil wordUtil) {
        String simpleWord = wordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            previewSearchResult.retainAll(index.getOccurredDocuments(simpleWord));
        return previewSearchResult;
    }
}
