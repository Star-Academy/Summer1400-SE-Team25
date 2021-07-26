package model.query;

import java.util.HashSet;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class ORQuery extends Query {
    public ORQuery(String queryString, InvertedIndex index) {
        this.queryString = queryString.substring(1);
        this.index = index;
    }

    @Override
    public HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        prevSearchResult.addAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
