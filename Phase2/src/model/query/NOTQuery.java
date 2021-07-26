package model.query;

import java.util.HashSet;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class NOTQuery extends Query {
    public NOTQuery(String queryString, InvertedIndex index) {
        super(index, queryString.substring(1));
    }

    @Override
    public HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        prevSearchResult.removeAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
