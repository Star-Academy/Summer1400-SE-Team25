package model;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/**
 * document -> index hashmap: word, list[index]
 */
public class InvertedIndex {
    private final HashMap<String, HashSet<DocumentFile>> invertedList;
    private final ArrayList<DocumentFile> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new ArrayList<>();
    }

    public ArrayList<DocumentFile> getDocuments() {
        return documentList;
    }

    public void addWord(String word, DocumentFile document) {
        if (!invertedList.containsKey(word))
            invertedList.put(word, new HashSet<>());
        invertedList.get(word).add(document);
    }

    public void addDocument(DocumentFile document) {
        documentList.add(document);
    }

    public int getDocumentCount() {
        return documentList.size();
    }

    public HashSet<DocumentFile> getOccurredDocuments(String word) {
        if (word == null || !invertedList.containsKey(word))
            return new HashSet<>();
        return invertedList.get(word);
    }
}
