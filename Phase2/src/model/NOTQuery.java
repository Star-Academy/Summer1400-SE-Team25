package model;

import java.util.HashSet;

import util.WordUtil;

public class NOTQuery extends Query {
    public NOTQuery(String queryString, InvertedIndex index) {
        this.queryString = queryString;
        this.index = index;
    }

    @Override
    public HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearhcResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        prevSearhcResult.removeAll(index.getOccurredDocuments(simpleWord));
        return prevSearhcResult;
    }
}
