package model;


import java.io.File;
import java.util.HashMap;
import java.util.Map;

public class FileMapper {
    private final Map<String, DocumentFile> documentFiles;

    public FileMapper() {
        documentFiles = new HashMap<>();
    }

    public DocumentFile getCorrespondingDocument(File file) {
        String fileName = file.getName();
        if (documentFiles.containsKey(fileName))
            return documentFiles.get(fileName);
        var newDocument = new DocumentFile(fileName, file.getAbsolutePath(), documentFiles.size());
        documentFiles.put(fileName, newDocument);
        return newDocument;
    }
}
