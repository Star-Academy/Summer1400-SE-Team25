package controller;

import java.util.ArrayList;
import java.util.HashSet;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.Query;

public class QueryHandler {
    private InvertedIndex invertedIndex;
    private ArrayList<Query> queriesList;

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
    }

    public HashSet<DocumentFile> search(String query) {
        setQueryList(query);
        HashSet<DocumentFile> res = new HashSet<>();
        for(Query i : queriesList)
            res = i.pushSearchResult(res);
        return res;
    }

    private void setQueryList(String query) {
        String[] subQueries = query.split(" ");
        for (String i : subQueries)
            queriesList.add(Query.getNewInstance(i, invertedIndex));
    }
}