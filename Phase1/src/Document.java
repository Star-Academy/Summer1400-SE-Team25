import java.io.File;
import java.util.Objects;

public class Document {
    private final File docFile;
    private final String fileName;
    private final int id;

    public Document(String fileName, String path, int id) {
        this.fileName = fileName;
        this.id = id;
        this.docFile = new File(path);
    }

    public String getFileName() {
        return fileName;
    }

    public int getId() {
        return id;
    }

    public File getFile() {
        return docFile;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Document)) return false;
        Document document = (Document) o;
        return Objects.equals(id, document.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }
}
