package controller;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.when;

import java.util.HashSet;

import org.junit.Before;
import org.junit.Test;
import org.mockito.Mock;

import model.DocumentFile;

public class SearchEngineTest {
    private SearchEngine engine;
    private final String searchQuery = "Test query";

    @Mock
    private QueryHandler queryHandler;
    private DocumentFile documentFile;

    @Before
    public void setUp() {
        var mockedSearchResult = new HashSet<DocumentFile>() {
            {
                add(documentFile);
            }
        };

        when(queryHandler.search(searchQuery)).thenReturn(mockedSearchResult);
        when(documentFile.toString()).thenReturn("Doc1");

        engine = new SearchEngine(queryHandler);
    }

    @Test
    public void searchTest() {
        String expectedResult = "Doc1";
        assertEquals(expectedResult, engine.search(searchQuery));
    }
}
