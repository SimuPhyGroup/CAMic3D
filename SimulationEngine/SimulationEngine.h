#pragma once

#include "HDF5Loader.h"

#ifdef SIMULATIONENGINE_EXPORTS
#define SIMULATIONENGINE_API __declspec(dllexport)
#else
#define SIMULATIONENGINE_API __declspec(dllimport)
#endif

extern "C" SIMULATIONENGINE_API void InitializeSimulation(const char* coordsFile, const char* timeFile, const char* tFile, const char* mfFile);
extern "C" SIMULATIONENGINE_API void RunSimulation(double parameter);
extern "C" SIMULATIONENGINE_API double GetSimulationResult();

class SimulationEngine {
public:
    void initialize(const std::string& coordsFile, const std::string& timeFile, const std::string& tFile, const std::string& mfFile);
    void run(double parameter);
    double getResult() const;

private:
    HDF5Loader loader;
    double result;
};
