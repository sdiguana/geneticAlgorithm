# geneticAlgorithm
Genetic Algorithm in C# to search for the values of a sentance

The Gene, Map & Fitness Classes are the items which determine what the GA Solves. Replacing these classes while maintaining the exposed methods will keep the remaining codebase working.

Notes: 
The code was developed on the fly to learn how GAs work. I will refactor it as time / need permits. 
There was no optimization of code performed during the development. I am sure there are performance bottlenecks that could be found/refactored. 


Usage:
Populations should be kept as small as is feasible to maintain adequate Genetic Diversity. In the current configuration, only 20 individuals is plenty to solve the sentance. Note that if a problem has local minima, a larger population is warranted as it could lead to getting trapped in that minima. Additionally the PropagateElitism Method reduces diversity, but increases the focus on the 'best' candidate. Reducing the number of children it produces will help diversity. 
