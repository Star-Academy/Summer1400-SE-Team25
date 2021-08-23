package modelTest;

import model.DocumentFile;
import model.FileMapper;
import model.InvertedIndex;
import org.junit.*;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import java.io.File;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class)
public class FileMapperTest {
    private FileMapper fileMapper;
    @Mock
    private InvertedIndex invertedIndex;

    private final String DOCUMENT_PATH = "src/main/java/EnglishData/57110";
    private final String DOCUMENT_WORD = "friend";
    private File documentFile;

    @Before
    public void initialize() {
        doNothing().when(invertedIndex).addWord(any(DocumentFile.class), any(String.class));
        doNothing().when(invertedIndex).addDocument(any(DocumentFile.class));
        fileMapper = new FileMapper(invertedIndex);
    }

    private void initializeFile() {
        documentFile = new File(DOCUMENT_PATH);
    }

    @Test(expected = IllegalStateException.class)
    public void testAddInvalidWord() {
        initializeFile();
        fileMapper.addWordToInvertedIndex(DOCUMENT_PATH, DOCUMENT_WORD);
    }

    @Test
    public void testAddValidWord() {
        initializeFile();
        fileMapper.addDocument(documentFile);
        fileMapper.addWordToInvertedIndex(documentFile.getName(), DOCUMENT_WORD);
    }

    @Test
    public void testDocumentTwice() {
        initializeFile();
        fileMapper.addDocument(documentFile);
        fileMapper.addDocument(documentFile);
    }
}
