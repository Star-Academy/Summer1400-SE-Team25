package controllerTest;

import static org.junit.Assert.assertTrue;
import static org.mockito.Mockito.when;

import java.util.HashSet;

import controller.QueryHandler;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;

import model.DocumentFile;
import model.InvertedIndex;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class QueryHandlerTest {
    private QueryHandler queryHandler;

    @Mock
    private InvertedIndex index;
    private DocumentFile document1;
    private DocumentFile document2;
    private DocumentFile document3;
    private DocumentFile document4;

    @Before
    public void setUp() {
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

        when(index.getOccurredDocuments("Test query1")).thenReturn(searchResult1);
        when(index.getOccurredDocuments("Test query2")).thenReturn(searchResult2);
        when(index.getOccurredDocuments("Test query3")).thenReturn(searchResult3);

        this.queryHandler = new QueryHandler(index);
    }

    @Test
    public void serachTest() {
        String searchQuery = "Test query1 +Test query2 -Test query3";

        var searchResult = queryHandler.search(searchQuery);
        var expectedResult = new HashSet<DocumentFile>(){
            {
                add(document2);
                add(document3);
            }
        };
        assertTrue(searchResult.equals(expectedResult));
    }
}
