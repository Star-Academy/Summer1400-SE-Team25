package controllerTest;

import static org.junit.Assert.*;
import static org.mockito.Mockito.*;


import controller.DirectoryHandler;
import controller.FileHandler;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import controller.QueryHandler;
import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

import java.io.File;

@RunWith(MockitoJUnitRunner.class)
public class DirectoryHandlerTest {
    private final String DIRECTORY = "src/main/java/EnglishData";
    private final int DOCUMENTS_COUNT = 999;
    private DirectoryHandler directoryHandler;
    private int documentsCount;

    @Mock
    FileHandler fileHandler;

    @Before
    public void initializeMocks() {
        doAnswer(invocationOnMock -> documentsCount++).when(fileHandler).addWordsToInvertedIndex(any(File.class));
        directoryHandler = new DirectoryHandler(fileHandler);
    }

    private void initializeProperties() {
        documentsCount = 0;
    }

    @Test
    public void testAddAllDocumentsFileMethod() {
        initializeProperties();
        directoryHandler.addAllDocumentsInDirectoryToInvertedIndex(DIRECTORY);
        assertEquals(documentsCount, DOCUMENTS_COUNT);
    }
}
