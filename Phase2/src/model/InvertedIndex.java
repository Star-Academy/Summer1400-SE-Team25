package model;

import java.io.File;
import java.util.*;

public class InvertedIndex {
    private final Map<String, Set<DocumentFile>> invertedList;
    private final List<DocumentFile> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new ArrayList<>();
    }

    public List<DocumentFile> getDocuments() {
        return documentList;
    }

    public void addWord(DocumentFile documentFile, String word) {
        if (!invertedList.containsKey(word))
            invertedList.put(word, new HashSet<>());
        invertedList.get(word).add(documentFile);
    }

    public void addDocument(DocumentFile newDocument) {
        documentList.add(newDocument);
    }

    public Set<DocumentFile> getOccurredDocuments(String word) {
        if (word == null || !invertedList.containsKey(word))
            return new HashSet<>();
        return invertedList.get(word);
    }
}
