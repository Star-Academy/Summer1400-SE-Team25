package model.query;

import java.util.Set;

import model.DocumentFile;

public interface Operator {
    Set<DocumentFile> operate(Set<DocumentFile> prevSearchResult);
}
