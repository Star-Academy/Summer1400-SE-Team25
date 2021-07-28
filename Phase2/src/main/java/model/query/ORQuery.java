package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class ORQuery extends Query {
    public ORQuery(String queryString, InvertedIndex index) {
        super(index, queryString.substring(1));
    }

    @Override
    public Set<DocumentFile> pushSearchResult(Set<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            prevSearchResult.addAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}