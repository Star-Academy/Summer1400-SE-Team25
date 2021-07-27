package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

public class ANDQuery extends Query {
    public ANDQuery(String queryString, InvertedIndex index) {
        super(index, queryString);
    }

    @Override
    public Set<DocumentFile> pushSearchResult(Set<DocumentFile> prevSearchResult) {
        String simpleWord = WordUtil.extractRootWord(queryString);
        if (simpleWord != null)
            prevSearchResult.retainAll(index.getOccurredDocuments(simpleWord));
        return prevSearchResult;
    }
}
