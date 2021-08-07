package controllerTest;

import static org.mockito.Mockito.*;
import static org.junit.Assert.*;

import controller.FileHandler;
import model.DocumentFile;
import model.FileMapper;
import model.InvertedIndex;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import java.io.File;

@RunWith(MockitoJUnitRunner.class)
public class FileHandlerTest {
    private final String VALID_PATH = "src/main/java/EnglishData/57110";
    private final int DOCUMENT_WORD_COUNT = 197;

    private File validFile;
    private FileHandler fileHandler;
    private int addedWordsCount;

    @Mock
    private DocumentFile documentFile;
    @Mock
    private FileMapper fileMapper;
    @Mock
    private InvertedIndex invertedIndex;

    @Before
    public void initializeMocks() {
        validFile = new File(VALID_PATH);
        this.fileHandler = new FileHandler(fileMapper, invertedIndex);
        doAnswer(invocationOnMock -> addedWordsCount++).when(invertedIndex).addWord(any(DocumentFile.class), any(String.class));
        when(fileMapper.getCorrespondingDocument(validFile)).thenReturn(documentFile);
    }

    @Test
    public void testAddWordToInvertedIndex() {
        addedWordsCount = 0;
        fileHandler.addWordsToInvertedIndex(validFile);
        assertEquals(addedWordsCount, DOCUMENT_WORD_COUNT);
    }
}
