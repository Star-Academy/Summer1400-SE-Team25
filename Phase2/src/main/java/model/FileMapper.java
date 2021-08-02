package model;


import java.io.File;
import java.util.HashMap;
import java.util.Map;

public class FileMapper {
    private final InvertedIndex invertedIndex;
    private final Map<String, DocumentFile> documentFiles;

    public FileMapper(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
        documentFiles = new HashMap<>();
    }

    public void addWordToInvertedIndex(String fileName, String word) {
        if (!documentFiles.containsKey(fileName))
            throw new IllegalStateException("File hasn't been added.");
        DocumentFile documentFile = documentFiles.get(fileName);
        invertedIndex.addWord(documentFile, word);
    }

    public void addDocument(File file) {
        if (documentFiles.containsKey(file.getName()))
            return;
        var newDocument = new DocumentFile(file.getName(), file.getAbsolutePath(), documentFiles.size());
        documentFiles.put(file.getName(), newDocument);
        invertedIndex.addDocument(newDocument);
    }
}
