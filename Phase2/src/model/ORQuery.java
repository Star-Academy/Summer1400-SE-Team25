package model;

import java.util.HashSet;

import util.WordUtil;

public class ORQuery extends Query {
    public ORQuery(String queryString, InvertedIndex index) {
        this.queryString = queryString.substring(1);
        this.index = index;
    }

    @Override
    public HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearhcResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        prevSearhcResult.addAll(index.getOccurredDocuments(simpleWord));
        return prevSearhcResult;
    }
}
