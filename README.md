# Unity-IronBellyTest-ErtanTuran
Test for IronBelly .


1. I have used my own object pooler can be found [here](https://github.com/ertanturan/Unity-Object-Pooling) 
2. Imported [Zenject](https://github.com/modesttree/Zenject) as my default dependency injection framework.
3. Since it's not performant to use vector3.distance or any equivalent function to find the nearest i thought it best to use a tree system. So I decided to use a [kdTree](https://gist.github.com/ditzel/194ec800053ce7083b73faa1be9101b0#file-kdtree-cs) just to make it performant and finish the task within the time limit.
4. *Reminder* To see lines between neighbours you must activate `Gizmos` in unity Editor.

Cheers !,
Ertan
