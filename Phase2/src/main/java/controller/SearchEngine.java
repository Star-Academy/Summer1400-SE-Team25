package controller;

import java.util.Set;

import model.DocumentFile;
import util.WordUtil;

public class SearchEngine {
    private final QueryHandler queryHandler;

    public SearchEngine(QueryHandler queryHandler) {
        this.queryHandler = queryHandler;
    }

    public String search(String searchQuery) {
        Set<DocumentFile> resultList = queryHandler.search(searchQuery, new WordUtil());
        return docListToString(resultList);
    }

    public static String docListToString(Set<DocumentFile> docList) {
        var result = new StringBuilder();
        for (DocumentFile file : docList)
            result.append(file.toString());
        return result.toString();
    }
}
