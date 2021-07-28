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

    private final static int DOCUMENT_PREVIEW_CHARACTER_COUNT = 27;
    private final static String END_OF_FILE_PREVIEW = "...";

    public DocumentFile(String fileName, String path, int id) {
        this.fileName = fileName;
        this.id = id;
        this.docFile = new File(path);
    }

    public String getFileName() {
        return fileName;
    }

    public String previewDocument(){
        StringBuilder result = new StringBuilder();
        try (Scanner docSc = new Scanner(new FileReader(docFile))) {
            String line = docSc.nextLine();
            result.append(getLinePreview(line));
            result.append(END_OF_FILE_PREVIEW);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return result.toString();
    }

    private String getLinePreview(String line) {
        int characterCount = Math.min(line.length(), DOCUMENT_PREVIEW_CHARACTER_COUNT);
        return line.substring(0, characterCount);
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
