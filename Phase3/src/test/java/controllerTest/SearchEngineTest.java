package controllerTest;

import static org.junit.Assert.*;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.when;

import java.util.HashSet;

import controller.QueryHandler;
import controller.SearchEngine;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;

import model.DocumentFile;
import org.mockito.junit.MockitoJUnitRunner;
import util.WordUtil;

@RunWith(MockitoJUnitRunner.class)
public class SearchEngineTest {
    private SearchEngine engine;
    private final String searchQuery = "Test query";

    @Mock
    private QueryHandler queryHandler;
    @Mock
    private DocumentFile documentFile;

    @Before
    public void setUp() {
        var mockedSearchResult = new HashSet<DocumentFile>() {
            {
                add(documentFile);
            }
        };

        when(queryHandler.search(any(String.class), any(WordUtil.class))).thenReturn(mockedSearchResult);
        when(documentFile.toString()).thenReturn("Doc1");
        engine = new SearchEngine(queryHandler);
    }

    @Test
    public void searchTest() {
        String expectedResult = "Doc1";
        assertEquals(expectedResult, engine.search(searchQuery));
    }
}
