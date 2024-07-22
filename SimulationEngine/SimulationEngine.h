#pragma once

#ifdef SIMULATIONENGINE_EXPORTS
#define SIMULATIONENGINE_API __declspec(dllexport)
#else
#define SIMULATIONENGINE_API __declspec(dllimport)
#endif

extern "C" SIMULATIONENGINE_API void RunSimulation(double parameter);
extern "C" SIMULATIONENGINE_API double GetSimulationResult();
