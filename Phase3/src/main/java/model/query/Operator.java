package model.query;

import java.util.Set;

import model.DocumentFile;
import util.WordUtil;

public interface Operator {
    Set<DocumentFile> operate(Set<DocumentFile> previewSearchResult, WordUtil wordUtil);
}
