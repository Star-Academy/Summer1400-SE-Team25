import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

import javax.swing.text.Document;

/**
 * document -> index hashmap: word, list[index]
 */
public class InvertedIndex {
    private final HashMap<String, HashSet<Document>> invertedList;
    private final ArrayList<Document> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new ArrayList<>();
    }

    public ArrayList<Document> getDocuments() {
        return documentList;
    }

    public void addWord(String word, Document document) {
        if (!invertedList.containsKey(word))
            invertedList.put(word, new HashSet<>());
        invertedList.get(word).add(document);
    }

    public void addDocument(Document document) {
        documentList.add(document);
    }

    public int getDocumentCount() {
        return documentList.size();
    }

    public HashSet<Document> getOccurredDocuments(String word) {
        if (!invertedList.containsKey(word))
            throw new IllegalArgumentException(word + "is not on the list.");
        if (word == null)
            return null;
        return invertedList.get(word);
    }
}
