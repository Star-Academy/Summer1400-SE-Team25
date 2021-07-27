package model;

import controller.FileHandler;

import java.io.File;
import java.util.*;

/**
 * document -> index hashmap: word, list[index]
 */
public class InvertedIndex {
    private final Map<String, Set<DocumentFile>> invertedList;
    private final List<DocumentFile> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new ArrayList<>();
        init();
    }

    private void init() {

    }

    public List<DocumentFile> getDocuments() {
        return documentList;
    }

//    public void addWord(File file, String word) {
//        if (!invertedList.containsKey(word))
//            invertedList.put(word, new HashSet<>());
//        invertedList.get(word).add(document);
//    }

//    private DocumentFile getDocumentByName(String documentName) {
//
//    }

    public void addDocument(File file) {
        DocumentFile newDocument = new DocumentFile(file.getName(), file.getAbsolutePath(), documentList.size());
        documentList.add(newDocument);
    }

    public Set<DocumentFile> getOccurredDocuments(String word) {
        if (word == null || !invertedList.containsKey(word))
            return new HashSet<>();
        return invertedList.get(word);
    }
}
