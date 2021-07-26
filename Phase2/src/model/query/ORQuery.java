package model.query;

import java.util.HashSet;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class ORQuery extends Query {
    public ORQuery(String queryString, InvertedIndex index) {
        super(index, queryString.substring(1));
    }

    @Override
    public HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        prevSearchResult.addAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
