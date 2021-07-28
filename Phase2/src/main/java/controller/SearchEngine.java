package controller;

import java.util.Set;

import model.DocumentFile;

public class SearchEngine {
    private final QueryHandler queryHandler;

    public SearchEngine(QueryHandler queryHandler) {
        this.queryHandler = queryHandler;
    }

    public String search(String searchQuery){
        StringBuilder resultString = new StringBuilder();
        Set<DocumentFile> resultList = queryHandler.search(searchQuery);
        for(DocumentFile document : resultList){
            resultString.append(document.getFileName());
            resultString.append(":\n\t");
            resultString.append(document.previewDocument());
            resultString.append("\n");
        }
        return resultString.toString();
    }
}
