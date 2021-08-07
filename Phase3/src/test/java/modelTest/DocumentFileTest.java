package modelTest;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotEquals;

import model.DocumentFile;
import org.junit.Before;
import org.junit.Test;

public class DocumentFileTest {
    private final String FIRST_DOCUMENT_NAME = "Test Document 1";
    private final String SECOND_DOCUMENT_NAME = "Test Document 2";
    private final String FIRST_DOCUMENT_PATH = "src/main/java/EnglishData/57110";
    private final String SECOND_DOCUMENT_PATH = "src/main/java/EnglishData/58043";
    private final String INVALID_DOCUMENT_PATH = "src/main/java/EnglishData/1";
    private final int FIRST_DOCUMENT_ID = 0;
    private final int SECOND_DOCUMENT_ID = 1;
    private final String FIRST_DOCUMENT_PREVIEW = "I have a 42 yr old male fri...";
    private DocumentFile firstDocumentFile;
    private DocumentFile secondDocumentFile;

    @Before
    public void initialize() {
        firstDocumentFile = new DocumentFile(FIRST_DOCUMENT_NAME, FIRST_DOCUMENT_PATH, FIRST_DOCUMENT_ID);
        secondDocumentFile = new DocumentFile(SECOND_DOCUMENT_NAME, SECOND_DOCUMENT_PATH, SECOND_DOCUMENT_ID);
    }

    @Test
    public void testException() {
        DocumentFile invalidDocument = new DocumentFile(FIRST_DOCUMENT_NAME, INVALID_DOCUMENT_PATH, FIRST_DOCUMENT_ID);
        invalidDocument.getPreviewDocument();
    }

    @Test
    public void testDocumentPreview() {
        String documentPreview = firstDocumentFile.getPreviewDocument();
        assertEquals(FIRST_DOCUMENT_PREVIEW, documentPreview);
    }

    @Test
    public void testToString() {
        String documentToString = firstDocumentFile.toString();
        String firstDocumentToString = FIRST_DOCUMENT_NAME + ":\n\t" + FIRST_DOCUMENT_PREVIEW + "\n";
        assertEquals(documentToString, firstDocumentToString);
    }

    @Test
    public void equalsTest() {
        Object object = new Object();
        assertEquals(firstDocumentFile, firstDocumentFile);
        assertNotEquals(firstDocumentFile, secondDocumentFile);
        assertNotEquals(firstDocumentFile, object);
    }

    @Test
    public void hashCodeTest() {
        assertEquals(firstDocumentFile.hashCode(), firstDocumentFile.hashCode());
        assertNotEquals(firstDocumentFile.hashCode(), secondDocumentFile.hashCode());
    }
}
