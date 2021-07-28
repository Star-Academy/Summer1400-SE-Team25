package controller;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.Operator;

public class QueryHandler {
    private final InvertedIndex invertedIndex;
    private final List<Operator> queriesList;

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
        queriesList = new ArrayList<>();
    }

    public Set<DocumentFile> search(String line) {
        setQueryList(line);
        Set<DocumentFile> resultSet = new HashSet<>(invertedIndex.getDocuments());
        for (Operator query : queriesList)
            resultSet = query.pushSearchResult(resultSet);
        return resultSet;
    }

    private void setQueryList(String query) {
        String[] subQueries = query.split("\\s+");
        for (String subQuery : subQueries)
            queriesList.add(Operator.getNewInstance(subQuery, invertedIndex));
    }
}