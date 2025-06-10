// See https://aka.ms/new-console-template for more information


int[] array = {8, 2, 5, 3, 4, 7, 6, 1};
MergeSort(array);


static void MergeSort(int[] arr)
{
    int size = arr.Length;
    if(size == 1)
        return;

    int rightIndex = 0;
    int mid = size / 2;
    int[] leftArr = new int[mid];
    int[] rightArr = new int[size -mid];
    for (int i = 0; i < size-1; i++)
    {
        if (i < mid)
        {
            leftArr[i] = arr[i];
        }
        else
        {
            
            rightArr[rightIndex] = arr[rightIndex];
            rightIndex++;
        }
    }
    MergeSort(leftArr);
    MergeSort(rightArr);
    Merge(leftArr, rightArr,arr);
}

static void Merge(int[] leftArray, int[] rightArray,int[] arr)
{
    int leftSize = arr.Length / 2;
    int rightSize = arr.Length - leftSize;
    int i = 0, l = 0, r = 0; //indices
		
    //check the conditions for merging
    while(l < leftSize && r < rightSize) {
        if(leftArray[l] < rightArray[r]) {
            arr[i] = leftArray[l];
            i++;
            l++;
        }
        else {
            arr[i] = rightArray[r];
            i++;
            r++;
        }
    }
    while(l < leftSize) {
        arr[i] = leftArray[l];
        i++;
        l++;
    }
    while(r < rightSize) {
        arr[i] = rightArray[r];
        i++;
        r++;
    }
}