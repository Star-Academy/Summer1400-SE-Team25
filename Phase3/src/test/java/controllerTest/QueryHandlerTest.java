package controllerTest;

import static org.junit.Assert.assertTrue;
import static org.mockito.Mockito.when;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import controller.QueryHandler;
import model.DocumentFile;
import model.InvertedIndex;
import util.WordUtil;

@RunWith(MockitoJUnitRunner.class)
public class QueryHandlerTest {
    private QueryHandler queryHandler;

    @Mock
    private InvertedIndex index;
    @Mock
    private DocumentFile document1;
    @Mock
    private DocumentFile document2;
    @Mock
    private DocumentFile document3;
    @Mock
    private DocumentFile document4;
    @Mock
    private WordUtil wordUtil;

    @Before
    public void setUp() {
        initializeDocuments();
        when(wordUtil.extractRootWord("Test_query1")).thenReturn("test_query1");
        when(wordUtil.extractRootWord("Test_query2")).thenReturn("test_query2");
        when(wordUtil.extractRootWord("Test_query3")).thenReturn("test_query3");
        this.queryHandler = new QueryHandler(index);
    }

    private void initializeDocuments() {
        var documentsList = getDocumentsList();
        when(index.getOccurredDocuments("test_query1")).thenReturn(documentsList.get(0));
        when(index.getOccurredDocuments("test_query2")).thenReturn(documentsList.get(1));
        when(index.getOccurredDocuments("test_query3")).thenReturn(documentsList.get(2));
        when(index.getDocuments()).thenReturn(documentsList.get(3));
    }

    private ArrayList<Set<DocumentFile>> getDocumentsList() {
        var searchResult1 = new HashSet<DocumentFile>() {
            {
                add(document1);
                add(document2);
                add(document3);
            }
        };
        var searchResult2 = new HashSet<DocumentFile>() {
            {
                add(document3);
                add(document4);
            }
        };
        var searchResult3 = new HashSet<DocumentFile>() {
            {
                add(document1);
                add(document4);
            }
        };
        var documentsSet = new HashSet<DocumentFile>(){
            {
                add(document1);
                add(document2);
                add(document3);
                add(document4);
            }
        };
        return new ArrayList<>(Arrays.asList(searchResult1, searchResult2, searchResult3, documentsSet));
    }

    @Test
    public void searchTest() {
        String searchQuery = "Test_query1 +Test_query2 -Test_query3";

        var searchResult = queryHandler.search(searchQuery, wordUtil);
        var expectedResult = new HashSet<DocumentFile>(){
            {
                add(document2);
                add(document3);
            }
        };
        assertTrue(searchResult.equals(expectedResult));
    }
}
