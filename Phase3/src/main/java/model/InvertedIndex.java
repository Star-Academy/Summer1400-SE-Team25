package model;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class InvertedIndex {
    private final Map<String, Set<DocumentFile>> invertedList;
    private final HashSet<DocumentFile> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new HashSet<>();
    }

    public Set<DocumentFile> getDocuments() {
        return documentList;
    }

    public void addWord(DocumentFile documentFile, String word) {
        if (!invertedList.containsKey(word)) {
            invertedList.put(word, new HashSet<>());
            documentList.add(documentFile);
        }
        invertedList.get(word).add(documentFile);
    }

    public Set<DocumentFile> getOccurredDocuments(String word) {
        if (word == null || !invertedList.containsKey(word))
            return new HashSet<>();
        return invertedList.get(word);
    }
}
