package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class NOTOperator extends Operator {
    public NOTOperator(String queryString, InvertedIndex index) {
        super(index, queryString.substring(1));
    }

    @Override
    public Set<DocumentFile> pushSearchResult(Set<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            prevSearchResult.removeAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
