package model;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class InvertedIndexTest {
    private InvertedIndex invertedIndex;
    private final String WORD = "friend";
    @Mock
    private DocumentFile documentFile;

    @Before
    public void initialize() {
//        when(documentFile.equals(any(Object.class))).thenReturn(true); TODO ask whether if this two lines are necessary or not
//        when(documentFile.hashCode()).thenReturn(WORD.hashCode());
    }

    private void initializeInvertedIndex() {
        invertedIndex = new InvertedIndex();
    }

    @Test
    public void testAddDocument() {
        initializeInvertedIndex();
        invertedIndex.addDocument(documentFile);
        DocumentFile newDocumentFile = invertedIndex.getDocuments().get(0);
        assertEquals(documentFile, newDocumentFile);
    }

    @Test
    public void testAddWord() {
        initializeInvertedIndex();
        invertedIndex.addWord(documentFile, WORD);
        var resultSet = invertedIndex.getOccurredDocuments(WORD);
        assertTrue(resultSet.contains(documentFile));
    }

    @Test
    public void testAddNullWord() {
        initializeInvertedIndex();
        var resultSet = invertedIndex.getOccurredDocuments(null);
        assertTrue(resultSet.isEmpty());
    }

    @Test
    public void testGetNullSet() {
        initializeInvertedIndex();
        var resultSet = invertedIndex.getOccurredDocuments(WORD);
        assertTrue(resultSet.isEmpty());
    }
}
