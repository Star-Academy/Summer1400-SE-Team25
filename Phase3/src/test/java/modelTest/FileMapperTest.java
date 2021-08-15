package modelTest;

import static org.mockito.Mockito.*;
import static org.junit.Assert.*;

import model.DocumentFile;
import model.FileMapper;
import model.InvertedIndex;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.mockito.junit.MockitoJUnitRunner;

import java.io.File;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class)
public class FileMapperTest {
    private final String VALID_DOCUMENT_PATH = "src/main/java/EnglishData/57110";
    private final String DOCUMENT_PREVIEW = "I have a 42 yr old male fri...";
    private FileMapper fileMapper;
    private File documentFile;

    @Before
    public void initializeMocks() {
        fileMapper = new FileMapper();
    }

    private void initializeFile() {
        documentFile = new File(VALID_DOCUMENT_PATH);
    }

    @Test
    public void testAddValidWord() {
        initializeFile();
        var receivedDocument = fileMapper.getCorrespondingDocument(documentFile);
        assertEquals(receivedDocument.getPreviewDocument(), DOCUMENT_PREVIEW);
    }

    @Test
    public void testDocumentTwice() {
        initializeFile();
        var receivedDocument1 = fileMapper.getCorrespondingDocument(documentFile);
        var receivedDocument2 = fileMapper.getCorrespondingDocument(documentFile);
        assertEquals(receivedDocument1, receivedDocument2);
    }
}
