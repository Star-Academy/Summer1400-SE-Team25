package model.query;

import java.util.HashSet;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class ANDQuery extends Query {
    public ANDQuery(String queryString, InvertedIndex index) {
        super(index, queryString);
    }

    @Override
    public HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        prevSearchResult.retainAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
