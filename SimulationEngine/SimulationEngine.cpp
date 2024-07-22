#include "SimulationEngine.h"

SimulationEngine engine;

extern "C" SIMULATIONENGINE_API void InitializeSimulation(const char* coordsFile, const char* timeFile, const char* tFile, const char* mfFile) {
    engine.initialize(coordsFile, timeFile, tFile, mfFile);
}

extern "C" SIMULATIONENGINE_API void RunSimulation(double parameter) {
    engine.run(parameter);
}

extern "C" SIMULATIONENGINE_API double GetSimulationResult() {
    return engine.getResult();
}

void SimulationEngine::initialize(const std::string& coordsFile, const std::string& timeFile, const std::string& tFile, const std::string& mfFile) {
    loader = HDF5Loader(coordsFile, timeFile, tFile, mfFile);
    loader.loadData();
}

void SimulationEngine::run(double parameter) {
    // Implement your simulation logic here using loader data
    // Example: result could be based on parameter and loaded data
    result = parameter * loader.getCoords()[0][0]; // Just a placeholder logic
}

double SimulationEngine::getResult() const {
    return result;
}
