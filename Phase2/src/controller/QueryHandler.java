package controller;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.Query;

public class QueryHandler {
    private InvertedIndex invertedIndex;
    private List<Query> queriesList;

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
        queriesList = new ArrayList<>();
    }

    public Set<DocumentFile> search(String queryLine) {
        setQueryList(queryLine);
        Set<DocumentFile> resultSet = new HashSet<>(invertedIndex.getDocuments());
        for (Query query : queriesList)
            resultSet = query.pushSearchResult(resultSet);
        return resultSet;
    }

    private void setQueryList(String query) {
        String[] subQueries = query.split("\\s+");
        for (String subQuery : subQueries)
            queriesList.add(Query.getNewInstance(subQuery, invertedIndex));
    }
}