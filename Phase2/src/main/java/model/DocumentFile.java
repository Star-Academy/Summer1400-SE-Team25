package model;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

public class DocumentFile {
    private final File docFile;
    private final String fileName;
    private final int id;
    public final static int DOCUMENT_PREVIEW_CHARACTER_COUNT = 27;

    public DocumentFile(String fileName, String path, int id) {
        this.fileName = fileName;
        this.id = id;
        this.docFile = new File(path);
    }

    public String getFileName() {
        return fileName;
    }

    public File getFile() {
        return docFile;
    }

    public String previewDocument(){
        StringBuilder res = new StringBuilder();
        try (Scanner docSc = new Scanner(new FileReader(docFile))) {
            String temp = docSc.nextLine();
            res.append(temp, 0, Math.min(temp.length(), DOCUMENT_PREVIEW_CHARACTER_COUNT));
            res.append("...");
        } catch (IOException e) {
            e.printStackTrace();
        }
        return res.toString();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof DocumentFile)) return false;
        DocumentFile document = (DocumentFile) o;
        return id == document.id;
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }
}
