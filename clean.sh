#!/bin/bash

find server -depth -name bin -exec rm -rf '{}' ';'
find server -depth -name obj -exec rm -rf '{}' ';'
